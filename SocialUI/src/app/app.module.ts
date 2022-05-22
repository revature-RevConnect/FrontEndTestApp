import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { AuthModule, AuthHttpInterceptor } from '@auth0/auth0-angular';
import { Router, RouterModule } from '@angular/router';
import { AppRoutingModule } from './app.routing';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

import { AppComponent } from './app.component';
import { HomeComponent } from './pages/home/home.component';
import { ProfileComponent } from './pages/profile/profile.component';
import { SettingsComponent } from './pages/settings/settings.component';
import { ChatComponent } from './pages/chat/chat.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { FooterComponent } from './components/footer/footer.component';
import { LoginComponent } from './components/login/login.component';
import { LogoutComponent } from './components/logout/logout.component';
import { PostfeedComponent } from './components/postfeed/postfeed.component';
import { PostComponent } from './components/post/post.component';
import { AddPostComponent } from './components/add-post/add-post.component';
import { CommentfeedComponent } from './components/commentfeed/commentfeed.component';
import { CommentComponent } from './components/comment/comment.component';
import { AddCommentComponent } from './components/add-comment/add-comment.component';
import { AddLikeComponent } from './components/add-like/add-like.component';
import { LikesComponent } from './components/likes/likes.component';
import { LoadingComponent } from './components/loading/loading.component';
import { DisplayprofileComponent } from './components/displayprofile/displayprofile.component';
import { DisplaysettingComponent } from './components/displaysetting/displaysetting.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    ProfileComponent,
    SettingsComponent,
    ChatComponent,
    NavbarComponent,
    FooterComponent,
    LoginComponent,
    LogoutComponent,
    PostfeedComponent,
    PostComponent,
    AddPostComponent,
    CommentfeedComponent,
    CommentComponent,
    AddCommentComponent,
    AddLikeComponent,
    LikesComponent,
    LoadingComponent,
    DisplayprofileComponent,
    DisplaysettingComponent,
  ],
  imports: [
    BrowserModule,
    FormsModule,
    RouterModule,
    AppRoutingModule,
    HttpClientModule,
    AuthModule.forRoot({
      domain: 'dev-d63d2wc5.us.auth0.com',
      clientId: 'P4JlEHEDUAuT1qZ8EMlTMUckKT9pIKR5',
      audience: 'https://TestRevConnect/api',
      //audience: "https://socialAPI/",
      apiUri: "https://testrevconnect.azurewebsites.net",
      //apiUri: "https://revceonnectapi.azurewebsites.net",
      appUri: "http://localhost:4200",
      httpInterceptor: {
        allowedList: [
          {
            uri: 'https://revceonnectapi.azurewebsites.net/*',
            tokenOptions: {
              audience: 'https://socialAPI/',
            }
          },
          {
            uri:'https://testrevconnect.azurewebsites.net/*',
            tokenOptions:{
              audience: 'https://TestRevConnect/api'
            }
          }
        ]
      }
    }),
  ],
  providers: [
    {
      provide:HTTP_INTERCEPTORS,
      useClass: AuthHttpInterceptor,
      multi: true,
    },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
