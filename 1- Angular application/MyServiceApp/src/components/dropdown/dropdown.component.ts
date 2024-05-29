import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import DropdownOption from './models/DropDownOption';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-dropdown',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './dropdown.component.html',
  styles: ``,
})
export class DropdownComponent implements OnInit {
  @Input() options!: Array<DropdownOption>;
  @Input() label = '';
  @Input() placeholder = '';
  @Input() emptyMessage = 'No options found';
  @Input() value: string | null = null;

  @Output() valueChange = new EventEmitter<string>();

  public ngOnInit(): void {
    if (!this.options || this.options.length === 0) {
      return;
    }

    if (!this.value && !this.placeholder) {
      this.onChange({ target: { value: this.options[0].value } });
    }
  }

  public onChange(event: any) {
    const newOption =
      event.target.value === 'null' ? null : event.target.value;
    this.valueChange.emit(newOption);
  }
}
