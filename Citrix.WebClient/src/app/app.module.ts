import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { NgbModule } from "@ng-bootstrap/ng-bootstrap";
import { HttpClientModule } from "@angular/common/http";

import { AppRoutingModule } from "./app-routing.module";
import { AppComponent } from "./app.component";
import { inputKoffie } from "./koffie/Input/inputKoffie.component";
import { KoffieBattleService } from "./shared/Koffie/koffie-battle.service";
import { KoffieBattleComponent } from "./koffie/battle/koffie-battle/koffie-battle.component";
import { JaarComponent } from "./koffie/JaarOverzicht/jaaroverzicht.component";
import { NavigationBarComponent } from "./shared/navigation-bar-top/navigation-bar.component";
import { HomeComponent } from "./shared/home/home.component";
import { HomeKoffieComponent } from "./koffie/home-koffie/home-koffie.component";
import { KlachtenComponent } from "./klachten/Klachten-home/klachten.component";
import { KlachtInputComponent } from "./klachten/klacht-input/klacht-input.component";

@NgModule({
  declarations: [
    AppComponent,
    inputKoffie,
    KoffieBattleComponent,
    JaarComponent,
    NavigationBarComponent,
    HomeComponent,
    HomeKoffieComponent,
    KlachtenComponent,
    KlachtInputComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    NgbModule,
    HttpClientModule
  ],
  providers: [KoffieBattleService],
  bootstrap: [AppComponent]
})
export class AppModule {}
