import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";

import { MovieRoutingModule } from "./movie-routing.module";
import { MoviePageComponent } from "./movie-page/movie-page.component";
import { MovieTypeDropdownComponent } from "../../business-components/movie-type-dropdown/movie-type-dropdown.component";

@NgModule({
  declarations: [MoviePageComponent],
  imports: [CommonModule, MovieRoutingModule, MovieTypeDropdownComponent],
})
export class MovieModule {}
