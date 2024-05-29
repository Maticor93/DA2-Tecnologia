import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ThirdPageComponent } from './third-page/third-page.component';
import { ChildComponent } from './child/child.component';
import { SecondChildComponent } from './second-child/second-child.component';

const routes: Routes = [
  {
    path: '',
    component: ThirdPageComponent,
    children: [
      {
        path: 'child',
        component: ChildComponent,
      },
      {
        path: 'second-child',
        component: SecondChildComponent,
      },
      {
        path: '',
        redirectTo: 'child',
        pathMatch: 'full',
      },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ThirdRoutingModule {}

