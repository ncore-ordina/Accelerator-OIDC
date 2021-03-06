﻿// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace IdentityServer
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> Ids =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email()
            };

        public static IEnumerable<ApiResource> Apis =>
            new ApiResource[]
            { };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {

new Client {
                    ClientId = "mvc",
                    ClientName = "MVC Client",
                    Enabled = true,
                    AllowedGrantTypes = GrantTypes.Implicit,
                    RequireConsent = true,
                    AllowRememberConsent = true,
                    RedirectUris =
                      new List<string> {"https://localhost:44302/signin-oidc"},
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile
                    }
},
            new Client
        {
            ClientId = "angularClient",
            ClientName = "JavaScript Client",
            //ClientUri = "http://identityserver.io",

            AllowedGrantTypes = GrantTypes.Implicit,
            AllowAccessTokensViaBrowser = true,

            RedirectUris =           { "http://localhost:4200" },
            PostLogoutRedirectUris = { "http://localhost:4200" },

            AllowedCorsOrigins = { "http://localhost:4200" },

            AllowedScopes =
            {
                IdentityServerConstants.StandardScopes.OpenId,
                IdentityServerConstants.StandardScopes.Profile,
                IdentityServerConstants.StandardScopes.Email,
            }
          }
            };



 
    };

}