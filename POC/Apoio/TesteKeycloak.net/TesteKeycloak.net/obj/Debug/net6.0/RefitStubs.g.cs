﻿// <auto-generated />
using System;
using System.Net.Http;
using System.Collections.Generic;
using TesteKeycloak.net.RefitInternalGenerated;

/* ******** Hey You! *********
 *
 * This is a generated file, and gets rewritten every time you build the
 * project. If you want to edit it, you need to edit the mustache template
 * in the Refit package */

#pragma warning disable
namespace TesteKeycloak.net.RefitInternalGenerated
{
    [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    [AttributeUsage (AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Constructor | AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Event | AttributeTargets.Interface | AttributeTargets.Delegate)]
    sealed class PreserveAttribute : Attribute
    {

        //
        // Fields
        //
        public bool AllMembers;

        public bool Conditional;
    }
}
#pragma warning restore

#pragma warning disable CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
#pragma warning disable CS8669 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context. Auto-generated code requires an explicit '#nullable' directive in source.
namespace TesteKeycloak.net.Interfaces
{
    using global::Refit;
    using global::TesteKeycloak.net.Models;

    /// <inheritdoc />
    [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    [global::System.Diagnostics.DebuggerNonUserCode]
    [Preserve]
    [global::System.Reflection.Obfuscation(Exclude=true)]
    partial class AutoGeneratedIKeycloakAPIClient : IKeycloakAPIClient
    {
        /// <inheritdoc />
        public HttpClient Client { get; protected set; }
        readonly IRequestBuilder requestBuilder;

        /// <inheritdoc />
        public AutoGeneratedIKeycloakAPIClient(HttpClient client, IRequestBuilder requestBuilder)
        {
            Client = client;
            this.requestBuilder = requestBuilder;
        }

        /// <inheritdoc />
        Task<AccessTokenResponse> IKeycloakAPIClient.GetAccessToken(AccessTokenRequest request)
        {
            var arguments = new object[] { request };
            var func = requestBuilder.BuildRestResultFuncForMethod("GetAccessToken", new Type[] { typeof(AccessTokenRequest) });
            return (Task<AccessTokenResponse>)func(Client, arguments);
        }
    }
}

namespace TesteKeycloak.net.Interfaces
{
    using global::Refit;
    using global::TesteKeycloak.net.Models;

    /// <inheritdoc />
    [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    [global::System.Diagnostics.DebuggerNonUserCode]
    [Preserve]
    [global::System.Reflection.Obfuscation(Exclude=true)]
    partial class AutoGeneratedIKeycloakAPIService : IKeycloakAPIService
    {
        /// <inheritdoc />
        public HttpClient Client { get; protected set; }
        readonly IRequestBuilder requestBuilder;

        /// <inheritdoc />
        public AutoGeneratedIKeycloakAPIService(HttpClient client, IRequestBuilder requestBuilder)
        {
            Client = client;
            this.requestBuilder = requestBuilder;
        }

        /// <inheritdoc />
        Task<AccessTokenResponse> IKeycloakAPIService.GetAccessTokenAsync(AccessTokenRequest request)
        {
            var arguments = new object[] { request };
            var func = requestBuilder.BuildRestResultFuncForMethod("GetAccessTokenAsync", new Type[] { typeof(AccessTokenRequest) });
            return (Task<AccessTokenResponse>)func(Client, arguments);
        }
    }
}

#pragma warning restore CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
#pragma warning restore CS8669 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context. Auto-generated code requires an explicit '#nullable' directive in source.
