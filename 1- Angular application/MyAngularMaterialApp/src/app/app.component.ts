import { Component } from '@angular/core';
import DropdownOption from '../components/dropdown/models/DropDownOption';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styles: [],
})
export class AppComponent {
  title = 'MyComponentApp';
  input: string = 'Hello World';
  elements: Array<DropdownOption> = [
    {
      value: '1',
      label: 'Option 1',
    },
    {
      value: '2',
      label: 'Option 2',
    },
    {
      value: '3',
      label: 'Option 3',
    },
  ];
  optionSelected: string | null = null;

  public onClick(): void {
    alert('Button clicked');
  }
}
