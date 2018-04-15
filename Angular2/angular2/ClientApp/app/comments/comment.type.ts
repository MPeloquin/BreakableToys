import { Account} from '../accounts/account.type'

export class Comment {
    text: string;
    datePosted: Date;
    replies: Comment[];
    author: Account;
}