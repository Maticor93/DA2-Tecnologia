import { Component, Input, OnDestroy, OnInit } from "@angular/core";
import { DropdownComponent } from "../../components/dropdown/dropdown.component";
import { MovieTypeService } from "../../backend/services/movie-type.service";
import { Subscription } from "rxjs";
import MovieTypesStatus from "./models/MovieTypesStatus";
import { CommonModule } from '@angular/common';

@Component({
  selector: "app-movie-type-dropdown",
  standalone: true,
  imports: [DropdownComponent, CommonModule],
  templateUrl: "./movie-type-dropdown.component.html",
  styles: ``,
})
export class MovieTypeDropdownComponent implements OnInit, OnDestroy {
  @Input() value: string | null = null;

  status: MovieTypesStatus = {
    loading: true,
    movieTypes: [],
  };

  private _movieTypeGetAllSubscription: Subscription | null = null;

  constructor(private readonly _movieTypeService: MovieTypeService) {}

  ngOnDestroy(): void {
    this._movieTypeGetAllSubscription?.unsubscribe();
  }

  ngOnInit(): void {
    this._movieTypeGetAllSubscription = this._movieTypeService
      .getAll()
      .subscribe({
        next: (movieTypes) => {
          this.status = {
            movieTypes: movieTypes.map((movieType) => ({
              value: movieType.id,
              label: movieType.name,
            })),
          };
        },
        error: (error) => {
          this.status = {
            movieTypes: [],
            error,
          };
        },
      });
  }
}
