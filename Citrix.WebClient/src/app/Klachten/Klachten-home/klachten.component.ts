import { Component, OnInit } from "@angular/core";
import { Klachten } from "src/app/shared/klachten/klachten.model";
import { HttpClient } from "@angular/common/http";
import { KlachtenServiceService } from "src/app/shared/klachten/klachten.service";
import { ActivatedRoute } from "@angular/router";

@Component({
  selector: "app-klachten",
  templateUrl: "./klachten.component.html",
  styleUrls: ["./klachten.component.css"]
})
export class KlachtenComponent implements OnInit {
  public TotaalKlachten: Klachten[]= [];
  AantalDezeMaand: number;

  constructor(
    private service: KlachtenServiceService,
    private http: HttpClient,
    private route: ActivatedRoute
  ) {}
  readonly rootURL = "https://localhost:44310/";

  ngOnInit() {
    this.LoadData();
  }
  LoadData() {
    this.http
      .get<Klachten[]>(this.rootURL + "api/klachten")
      .subscribe(result => {
        this.TotaalKlachten = result;
        return this.TotaalKlachten;
      });
  }
}
