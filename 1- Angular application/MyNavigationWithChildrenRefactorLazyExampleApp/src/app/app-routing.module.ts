import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';

const routes: Routes = [
  {
    path: 'first-component',
    loadChildren: () =>
      import('./first/first.module').then((m) => m.FirstModule),
  },
  {
    path: 'second-component',
    loadChildren: () =>
      import('./second/second.module').then((m) => m.SecondModule),
  },
  {
    path: 'third-component',
    loadChildren: () =>
      import('./third/third.module').then((m) => m.ThirdModule),
  },
  { path: '', redirectTo: '/first-component', pathMatch: 'full' },
  { path: '**', component: PageNotFoundComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
