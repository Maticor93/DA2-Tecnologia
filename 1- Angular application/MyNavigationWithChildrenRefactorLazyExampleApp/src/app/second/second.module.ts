import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SecondPageComponent } from './second-page/second-page.component';

@NgModule({
  declarations: [SecondPageComponent],
  imports: [CommonModule],
  exports: [SecondPageComponent],
})
export class SecondModule {}
