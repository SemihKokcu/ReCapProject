using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspect.Autofac.Validation
{
    public class ValidationAspect : MethodInterception
    {
        // validtor type istiyor
        private Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new System.Exception("Bu bir doğrulama sınıfı değil");
            }

            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            // Reflection: çalışma anında birşeyleri çalıştırmayı sağlıyor,
            var validator = (IValidator)Activator.CreateInstance(_validatorType);// generic argumanlarından ilkini alıp parametrelerini buluyor, methodun paramterelerini alıyor
            var entityType = _validatorType.BaseType.GetGenericArguments()[0]; // 0.attribute <Product> gibi burayı al 
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType); // her birini gez ValidationTool kullanarak validate et
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}
