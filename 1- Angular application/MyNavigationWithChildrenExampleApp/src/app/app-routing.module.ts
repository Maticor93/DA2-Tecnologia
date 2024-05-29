import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FirstPageComponent } from './first-page/first-page.component';
import { SecondPageComponent } from './second-page/second-page.component';
import { ThirdPageComponent } from './third-page/third-page.component';
import { ChildComponent } from './child/child.component';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { SecondChildComponent } from './second-child/second-child.component';

const routes: Routes = [
  { path: 'first-component', component: FirstPageComponent },
  { path: 'second-component', component: SecondPageComponent },
  {
    path: 'third-component',
    component: ThirdPageComponent,
    children: [
      { path: 'child', component: ChildComponent },
      { path: 'second-child', component: SecondChildComponent },
      { path: '', redirectTo: 'child', pathMatch: 'full' },
    ],
  },
  { path: '', redirectTo: '/first-component', pathMatch: 'full' },
  { path: '**', component: PageNotFoundComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule { }
