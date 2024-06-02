import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";

import { AuthenticationRoutingModule } from "./authentication-routing.module";
import { AuthenticationPageComponent } from "./authentication-page/authentication-page.component";
import { LoginFormComponent } from "./login-form/login-form.component";
import { FormComponent } from "../../components/form/form/form.component";
import { FormInputComponent } from '../../components/form/form-input/form-input.component';
import { FormButtonComponent } from '../../components/form/form-button/form-button.component';

@NgModule({
  declarations: [AuthenticationPageComponent, LoginFormComponent],
  imports: [
    CommonModule,
    AuthenticationRoutingModule,
    FormComponent,
    FormInputComponent,
    FormButtonComponent
  ],
  exports: [LoginFormComponent],
})
export class AuthenticationModule {}
