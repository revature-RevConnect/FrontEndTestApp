import { NgModule} from "@angular/core";
import {Routes, RouterModule} from '@angular/router';

import { HomeComponent } from "./pages/home/home.component";
import { ProfileComponent } from "./pages/profile/profile.component";
import { SettingsComponent } from "./pages/settings/settings.component";
import { ChatComponent } from "./pages/chat/chat.component";
import { AuthGuard } from "@auth0/auth0-angular";

const routes: Routes = [
    {
        path: '',
        component: HomeComponent
    },
    {
        path: 'profile',
        component: ProfileComponent,
        canActivate: [AuthGuard],
    },
    {
        path: 'settings',
        component:SettingsComponent,
        canActivate: [AuthGuard],
    },
    {
        path:'chat',
        component:ChatComponent,
        canActivate: [AuthGuard],
    }

];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})

export class AppRoutingModule{}