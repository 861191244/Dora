﻿using System;
using System.Reflection;

namespace Dora.Interception
{
    /// <summary>
    ///Defines methods to resolve interceptor providers applied to specified type and method. 
    /// </summary>
    public interface IInterceptorProviderResolver
    {
        /// <summary>
        /// Determine whether the specified type should be intercepted.
        /// </summary>
        /// <param name="targetType">The type to be checked for interception.</param>
        /// <returns>
        /// A <see cref="Nullable{Boolean}" /> indicating whether the specified type should be intercepted.
        /// </returns>
        bool? WillIntercept(Type targetType);

        /// <summary>
        /// Gets the interceptor providers applied to the specified type.
        /// </summary>
        /// <param name="targetType">The type to which the interceptor providers are applied to.</param>
        /// <returns>The interceptor providers applied to the specified type.</returns>
        IInterceptorProvider[] GetInterceptorProvidersForType(Type targetType);

        /// <summary>
        /// Gets the interceptor providers applied to the specified method.
        /// </summary>
        /// <param name="targetType">Type of the target.</param>
        /// <param name="targetMethod">The method to which the interceptor providers are applied to.</param>
        /// <returns>
        /// The interceptor providers applied to the specified method.
        /// </returns>
        IInterceptorProvider[] GetInterceptorProvidersForMethod(Type targetType, MethodInfo targetMethod);


        /// <summary>
        /// Gets the interceptor providers applied to the specified method.
        /// </summary>
        /// <param name="targetType">Type of the target.</param>
        /// <param name="targetProperty">The property to which the interceptor providers are applied to.</param>
        /// <param name="getOrSet">The property's GET or SET method.</param>
        /// <returns>
        /// The interceptor providers applied to the specified method.
        /// </returns>
        IInterceptorProvider[] GetInterceptorProvidersForProperty(Type targetType, PropertyInfo targetProperty, PropertyMethod getOrSet);
    }
}
