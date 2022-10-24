using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Caching;
using Core.IoC;
using Core.Utilities.Interceptors;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspect.Autofac.Caching
{
    public class CacheAspect : MethodInterception
    {
        private int _duration;
        private ICacheManager _cacheManager;
        // default süre bu kadar süre durucak cache de 
        public CacheAspect(int duration = 60)
        {
            _duration = duration;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>(); //service tool yardımıyla hangi cache manager kullandığımı söylüyorum
        }//başka bir cache kullanacağım zaman burada bir şey değğiştirmek yok, coremodule'de injection yapmak

        public override void Intercept(IInvocation invocation)
        {   //reflectiondan namei alıyoruz: örn: 
            var methodName = string.Format($"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}");
            var arguments = invocation.Arguments.ToList();
            var key = $"{methodName}({string.Join(",", arguments.Select(x => x?.ToString() ?? "<Null>"))})";
            if (_cacheManager.IsAdd(key))
            {
                invocation.ReturnValue = _cacheManager.Get(key);
                return;
            }
            invocation.Proceed();
            _cacheManager.Add(key, invocation.ReturnValue, _duration);
        }
    }
