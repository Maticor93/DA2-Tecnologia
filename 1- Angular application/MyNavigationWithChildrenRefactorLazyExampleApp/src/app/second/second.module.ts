import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SecondPageComponent } from './second-page/second-page.component';
import { SecondRoutingModule } from './second-routing.module';

@NgModule({
  declarations: [SecondPageComponent],
  imports: [CommonModule, SecondRoutingModule],
  exports: [],
})
export class SecondModule {}
