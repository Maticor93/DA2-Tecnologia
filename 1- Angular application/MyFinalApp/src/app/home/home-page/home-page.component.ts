import { Component, OnInit } from "@angular/core";
import { SessionService } from "../../../backend/services/session/session.service";

@Component({
  selector: "app-home-page",
  templateUrl: "./home-page.component.html",
  styles: ``,
})
export class HomePageComponent implements OnInit {
  permissions: Array<string> = [];

  constructor(private readonly _sessionService: SessionService) {}

  ngOnInit(): void {
    this._sessionService.userLogged.subscribe({
      next: (userLogged) => {
        this.permissions = userLogged?.permissions ?? [];
      },
    });
  }
}
