using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Idp
{
    public class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
              new IdentityResource[]
              {
                new IdentityResources.OpenId()
              };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("ids4.api","ids4.api")
            };
        public static IEnumerable<ApiResource> apiResources => new ApiResource[] {
        new ApiResource("ids4.api","ids4.api")
        };
        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                new Client(){
            ClientId="ids4.api",
            ClientSecrets=new []{ new Secret("ids4.api".Sha256())},
            AllowedGrantTypes=GrantTypes.ResourceOwnerPasswordAndClientCredentials,
            AllowedScopes=new []{ "ids4.api"}
            } };

        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResource("roles", "角色", new List<string> { JwtClaimTypes.Role }),
            };
        }

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource> {
                new ApiResource("blog.core.api", "Blog.Core API") {
                    // include the following using claims in access token (in addition to subject id)
                    //requires using using IdentityModel;
                    UserClaims = { JwtClaimTypes.Name, JwtClaimTypes.Role }
                }
            };
        }
        public static IEnumerable<Client> GetClients()
        {
            // javascript client
            return new List<Client> {
                new Client {
                    ClientId = "blogvuejs",
                    ClientName = "Blog.Vue JavaScript Client",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    AllowAccessTokensViaBrowser = true,

                    RedirectUris =           { "http://localhost:6688/callback" },
                    PostLogoutRedirectUris = { "http://localhost:6688" },
                    AllowedCorsOrigins =     { "http://localhost:6688" },

                    AllowedScopes = {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "roles",
                        "blog.core.api"
                    }
                }
            };
        }
        public static List<TestUser> GetUsers()
        {
            return new List<TestUser>
        {
            new TestUser
            {
                SubjectId = "1",
                Username = "alice",
                Password = "password"
            },
            new TestUser
            {
                SubjectId = "2",
                Username = "bob",
                Password = "password"
            }
        };
        }
    }
}
