import { HttpClientModule } from "@angular/common/http";
import { APP_INITIALIZER, NgModule } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";
import {
  AuthModule,
  ConfigResult,
  OidcConfigService,
  OidcSecurityService,
  OpenIdConfiguration,
} from "angular-auth-oidc-client";
import { AppRoutingModule } from "./app-routing.module";
import { AppComponent } from "./app.component";

const oidcConfiguration = "assets/auth.clientConfiguration.json";

export function loadConfig(oidcConfigService: OidcConfigService) {
  return () => oidcConfigService.load(oidcConfiguration);
}
@NgModule({
  declarations: [AppComponent],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    AuthModule.forRoot(),
  ],
  providers: [
    OidcConfigService,
    {
      provide: APP_INITIALIZER,
      useFactory: loadConfig,
      deps: [OidcConfigService],
      multi: true,
    },
  ],
  bootstrap: [AppComponent],
})
export class AppModule {
  constructor(
    private oidcSecurityService: OidcSecurityService,
    private oidcConfigService: OidcConfigService
  ) {
    this.oidcConfigService.onConfigurationLoaded.subscribe(
      (configResult: ConfigResult) => {
        // Use the configResult to set the configurations

        const config: OpenIdConfiguration = {
          stsServer: "https://localhost:44303",
          redirect_url: "http://localhost:4200",
          client_id: "angularClient",
          scope: "openid profile email",
          response_type: "id_token token",
          silent_renew: true,
          silent_renew_url: "http://localhost:4200/silent-renew.html",
          log_console_debug_active: true,
          // all other properties you want to set
        };

        this.oidcSecurityService.setupModule(
          config,
          configResult.authWellknownEndpoints
        );
      }
    );
  }
}
