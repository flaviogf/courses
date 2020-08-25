interface CreateUserData {
  name?: string;
  email: string;
  password: string;
}

export function createUser({ name, email, password }: CreateUserData) {
  const user = {
    name,
    email,
    password,
  };

  return user;
}
