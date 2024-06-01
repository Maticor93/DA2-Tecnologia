import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";

import { AuthenticationRoutingModule } from "./authentication-routing.module";
import { AuthenticationPageComponent } from "./authentication-page/authentication-page.component";
import { LoginFormComponent } from "./login-form/login-form.component";

@NgModule({
  declarations: [AuthenticationPageComponent, LoginFormComponent],
  imports: [
    CommonModule,
    AuthenticationRoutingModule
  ],
})
export class AuthenticationModule {}
