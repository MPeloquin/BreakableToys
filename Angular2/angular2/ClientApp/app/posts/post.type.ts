import { Comment } from '../comments/comment.type'
import { Account } from '../accounts/account.type'

export class Post {
    id: number;
    title: string;
    url: string;
    creationDate: Date;
    comments: Comment[]
    author: Account;

    upvotes: number;
}