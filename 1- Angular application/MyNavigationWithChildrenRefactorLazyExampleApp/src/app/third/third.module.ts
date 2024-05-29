import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ThirdPageComponent } from './third-page/third-page.component';
import { ChildComponent } from './child/child.component';
import { SecondChildComponent } from './second-child/second-child.component';
import { RouterModule } from '@angular/router';

@NgModule({
  declarations: [ThirdPageComponent, ChildComponent, SecondChildComponent],
  imports: [CommonModule, RouterModule],
  exports: [ThirdPageComponent, ChildComponent, SecondChildComponent],
})
export class ThirdModule {}
