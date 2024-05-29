import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MovieRoutingModule } from './movie-routing.module';
import { MoviePageComponent } from './movie-page/movie-page.component';

@NgModule({
  declarations: [MoviePageComponent],
  imports: [CommonModule, MovieRoutingModule],
})
export class MovieModule {}
