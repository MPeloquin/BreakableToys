import { Comment } from '../comment/comment.type'
import { User } from '../user/user.type'

export class Post {
    id: number;
    title: string;
    url: string;
    creationDate: Date;
    comments: Comment[]
    author: User;

    upvotes: number;
}