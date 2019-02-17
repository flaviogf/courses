import * as mongoose from 'mongoose';

export interface User extends mongoose.Document {
    email: string;
    name: string;
    password: string;
}

const schema = new mongoose.Schema({
  email: {
    type: String,
    unique: true,
  },
  name: {
    type: String,
  },
  password: {
    type: String,
  },
});

export const User = mongoose.model<User>('User', schema);
