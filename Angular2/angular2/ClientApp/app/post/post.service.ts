import { Injectable } from '@angular/core';
import { Post } from './post.type';
import { Observable } from 'rxjs/Observable';
import { of } from 'rxjs/observable/of';

@Injectable()
export class PostService {
    private posts: Post[] = [
        { id: 1, title: "Test", url: "https://www.google.com", upvotes: 0, creationDate: new Date(), comments: [], author: { userName: "Maxime", creationDate: new Date() } },
        { id: 2, title: "Test2", url: "www.google.com", upvotes: 0, creationDate: new Date(), comments: [], author: { userName: "John", creationDate: new Date() } },
        { id: 3, title: "Test3", url: "www.google.com", upvotes: 0, creationDate: new Date(), comments: [], author: { userName: "Frank", creationDate: new Date() } }
    ];

    getTopPosts(): Observable<Post[]> {
        return of(this.posts);
    }

    getPost(id: number): Observable<Post> {
        return of(this.posts.find(post => post.id == id)!);
    }
}
