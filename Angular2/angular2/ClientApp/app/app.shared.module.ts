import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app/app.component';
import { HomeComponent } from './home/home.component';
import { HeaderComponent } from './shared/header/header.component'
import { PostSummaryComponent } from './post/post-summary/post-summary.component';
import { PostDetailComponent } from './post/post-details/post-detail.component';
import { PostService } from './post/post.service';

@NgModule({
    declarations: [
        AppComponent,
        HomeComponent,
        HeaderComponent,
        PostSummaryComponent,
        PostDetailComponent,

    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'post/:id', component: PostDetailComponent },
            { path: '**', redirectTo: 'home' }
        ])
    ],
    providers: [
        PostService
    ]
})
export class AppModuleShared {
}
