import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { NgbModule } from "@ng-bootstrap/ng-bootstrap";
import { HttpClientModule } from "@angular/common/http";

import { AppRoutingModule } from "./app-routing.module";
import { AppComponent } from "./app.component";
import { ManagersComponent } from "./managers/managers.component";
import { ManagerListService } from "./shared/Manager/manager-list.service";
import { inputKoffie } from "./koffie/Input/inputKoffie.component";
import { KoffieBattleService } from "./shared/Koffie/koffie-battle.service";
import { KoffieBattleComponent } from "./koffie/battle/koffie-battle/koffie-battle.component";
import { JaarComponent } from "./koffie/JaarOverzicht/jaaroverzicht.component";
import { NavigationBarComponent } from "./shared/navigation-bar-top/navigation-bar.component";
import { MatSidenavModule } from "@angular/material";
import { HomeComponent } from "./shared/home/home.component";
import { HomeKoffieComponent } from "./koffie/home-koffie/home-koffie.component";

@NgModule({
  declarations: [
    AppComponent,
    ManagersComponent,
    inputKoffie,
    KoffieBattleComponent,
    JaarComponent,
    NavigationBarComponent,
    HomeComponent,
    HomeKoffieComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    NgbModule,
    HttpClientModule
  ],
  providers: [ManagerListService, KoffieBattleService],
  bootstrap: [AppComponent]
})
export class AppModule {}
