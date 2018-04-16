import { Component, Input } from '@angular/core';
import { Post } from '../post.type';
import { PostService } from '../post.service';
import { ActivatedRoute } from '@angular/router';


@Component({
    selector: 'post-detail',
    templateUrl: './post-detail.component.html'
})
export class PostDetailComponent {
    post: Post;

    constructor(private postService: PostService, private route: ActivatedRoute) {
        const id = +this.route.snapshot.paramMap.get('id')!;

        postService.getPost(id).subscribe(post => this.post = post);
    }
}
