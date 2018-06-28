import { NameIdPair } from './nameIdPair';

export interface Booking {
  bookingId: number;
  bookingDate: Date;
  hallOwner: NameIdPair;
  customer: NameIdPair;
}
