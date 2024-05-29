import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ThirdPageComponent } from './third-page/third-page.component';
import { ChildComponent } from './child/child.component';
import { SecondChildComponent } from './second-child/second-child.component';
import { ThirdRoutingModule } from './third-routing.module';

@NgModule({
  declarations: [ThirdPageComponent, ChildComponent, SecondChildComponent],
  imports: [CommonModule, ThirdRoutingModule],
  exports: [],
})
export class ThirdModule {}
