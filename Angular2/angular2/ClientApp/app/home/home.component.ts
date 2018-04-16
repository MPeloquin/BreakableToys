import { Component } from '@angular/core';
import { Post } from '../post/post.type';
import { PostService } from '../post/post.service';


@Component({
    selector: 'home',
    templateUrl: './home.component.html'
})
export class HomeComponent {
    posts: Post[];
    constructor(private postService: PostService) {
        postService.getTopPosts().subscribe(posts => this.posts = posts);;
    }
}
