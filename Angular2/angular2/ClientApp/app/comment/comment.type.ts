import { User} from '../user/user.type'

export class Comment {
    text: string;
    datePosted: Date;
    replies: Comment[];
    author: User;
}