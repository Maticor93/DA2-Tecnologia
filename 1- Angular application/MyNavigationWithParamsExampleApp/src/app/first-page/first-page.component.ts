import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-first-page',
  templateUrl: './first-page.component.html',
  styles: ``,
})
export class FirstPageComponent implements OnInit, OnDestroy {
  public parameter: string = '';
  private _paramsSubscription: Subscription | null = null;

  constructor(private route: ActivatedRoute) {}
  ngOnDestroy(): void {
    this._paramsSubscription?.unsubscribe();
  }

  ngOnInit(): void {
    this._paramsSubscription = this.route.params.subscribe((params) => {
      this.parameter = params['param'];
    });
  }
}
