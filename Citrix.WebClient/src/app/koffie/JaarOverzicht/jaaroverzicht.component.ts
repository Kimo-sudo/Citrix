import { Component, OnInit } from "@angular/core";
import { KoffieBattle } from "src/app/shared/Koffie/koffie-battle.model";
import { KoffieBattleService } from "src/app/shared/Koffie/koffie-battle.service";
import { HttpClient } from "@angular/common/http";
import { KoffieBattleComponent } from "../battle/koffie-battle/koffie-battle.component";
import { ActivatedRoute } from "@angular/router";

@Component({
  selector: "app-jaaroverzicht",
  templateUrl: "./jaaroverzicht.component.html",
  styleUrls: ["./jaaroverzicht.component.css"]
})
export class JaarComponent implements OnInit {
  public KoffieVerkocht: KoffieBattle[];
  restaurant: string;

  constructor(
    private service: KoffieBattleService,
    private http: HttpClient,
    private route: ActivatedRoute
  ) {}

  ngOnInit() {
    this.restaurant = this.route.snapshot.paramMap.get("restaurant");
    this.LoadData();
  }
  LoadData() {
    this.http
      .get<KoffieBattle[]>(
        this.service.rootURL + "koffie/year/2020/" + this.restaurant
      )
      .subscribe(result => {
        this.KoffieVerkocht = result;
        return this.KoffieVerkocht;
      });
  }
}
