import { Component, Input } from '@angular/core';
import { Post } from '../post.type';

@Component({
    selector: 'post-summary',
    templateUrl: './post-summary.component.html'
})
export class PostSummaryComponent {
    @Input() post: Post;

    constructor() {
    }
}
