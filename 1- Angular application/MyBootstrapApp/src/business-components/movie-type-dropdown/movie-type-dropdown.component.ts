import { Component, Input } from '@angular/core';
import { DropdownComponent } from '../../components/dropdown/dropdown.component';
import DropdownOption from '../../components/dropdown/models/DropDownOption';

@Component({
  selector: 'app-movie-type-dropdown',
  standalone: true,
  imports: [DropdownComponent],
  templateUrl: './movie-type-dropdown.component.html',
  styles: ``,
})
export class MovieTypeDropdownComponent {
  movieTypes: Array<DropdownOption> = [
    { label: 'Action', value: 'action' },
    { label: 'Comedy', value: 'comedy' },
    { label: 'Drama', value: 'drama' },
    { label: 'Horror', value: 'horror' },
    { label: 'Sci-Fi', value: 'sci-fi' },
  ];
  @Input() value: string | null = null;
}
