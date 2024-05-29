import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FirstPageComponent } from './first-page/first-page.component';
import { FirstRoutingModule } from './first-routing.module';

@NgModule({
  declarations: [FirstPageComponent],
  imports: [CommonModule, FirstRoutingModule],
  exports: [],
})
export class FirstModule {}
