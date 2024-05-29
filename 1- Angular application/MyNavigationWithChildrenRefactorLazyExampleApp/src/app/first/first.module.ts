import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FirstPageComponent } from './first-page/first-page.component';

@NgModule({
  declarations: [FirstPageComponent],
  imports: [CommonModule],
  exports: [FirstPageComponent],
})
export class FirstModule {}
