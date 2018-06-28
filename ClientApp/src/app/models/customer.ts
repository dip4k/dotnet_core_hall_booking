import { User } from './user';

export interface Customer {
  Id: number;
  address: string;
  aadharNo: string;
  user: User;
}
