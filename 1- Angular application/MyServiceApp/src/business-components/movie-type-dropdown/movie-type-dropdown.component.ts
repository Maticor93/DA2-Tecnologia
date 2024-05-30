import { Component, Input, OnDestroy, OnInit } from "@angular/core";
import { DropdownComponent } from "../../components/dropdown/dropdown.component";
import DropdownOption from "../../components/dropdown/models/DropDownOption";
import { MovieTypeService } from "../../services/movie-type.service";
import { Subscription } from "rxjs";

@Component({
  selector: "app-movie-type-dropdown",
  standalone: true,
  imports: [DropdownComponent],
  templateUrl: "./movie-type-dropdown.component.html",
  styles: ``,
})
export class MovieTypeDropdownComponent implements OnInit, OnDestroy {
  @Input() value: string | null = null;

  movieTypes: Array<DropdownOption> = [];

  private _movieTypeGetAllSubscription: Subscription | null = null;

  constructor(private readonly _movieTypeService: MovieTypeService) {}

  ngOnDestroy(): void {
    this._movieTypeGetAllSubscription?.unsubscribe();
  }

  ngOnInit(): void {
    this._movieTypeGetAllSubscription = this._movieTypeService
      .getAll()
      .subscribe((movieTypes) => {
        this.movieTypes = movieTypes.map((movieType) => ({
          value: movieType.id,
          label: movieType.name,
        }));
      });
  }
}
