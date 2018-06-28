import { User } from './user';

export interface Admin {
  adminId: number;
  name: string;
  email: string;
  user: User;
}
