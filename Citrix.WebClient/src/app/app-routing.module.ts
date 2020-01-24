import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";

import { JaarComponent } from "./koffie/JaarOverzicht/jaaroverzicht.component";
import { KoffieBattleComponent } from "./koffie/battle/koffie-battle/koffie-battle.component";
import { HomeComponent } from "./shared/home/home.component";
import { HomeKoffieComponent } from "./koffie/home-koffie/home-koffie.component";
import { inputKoffie } from "./koffie/Input/inputKoffie.component";

const routes: Routes = [
  { path: "current", component: KoffieBattleComponent },
  { path: "jaar", component: JaarComponent },
  {
    path: "koffie",
    component: HomeKoffieComponent
  },

  { path: "jaar/:restaurant", component: JaarComponent },
  { path: "", component: HomeComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { onSameUrlNavigation: "reload" })],
  exports: [RouterModule]
})
export class AppRoutingModule {}
