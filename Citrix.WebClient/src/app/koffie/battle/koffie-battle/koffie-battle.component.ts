import { Component, OnInit, Inject } from "@angular/core";
import { KoffieBattle } from "src/app/shared/Koffie/koffie-battle.model";
import { HttpClient } from "@angular/common/http";
import { KoffieBattleService } from "src/app/shared/Koffie/koffie-battle.service";
import { Injectable } from "@angular/core";

@Injectable({
  providedIn: "root"
})
@Component({
  selector: "app-koffie-battle",
  templateUrl: "./koffie-battle.component.html",
  styleUrls: ["./koffie-battle.component.css"]
})
export class KoffieBattleComponent implements OnInit {
  public KoffieVerkocht: KoffieBattle[];
  restaurant: string;
  constructor(private service: KoffieBattleService, private http: HttpClient) {}

  ngOnInit() {
    this.LoadData();
  }
  LoadData() {
    this.http
      .get<KoffieBattle[]>(this.service.rootURL + "koffie")
      .subscribe(result => {
        this.KoffieVerkocht = result;
        return this.KoffieVerkocht;
      });
  }
}
