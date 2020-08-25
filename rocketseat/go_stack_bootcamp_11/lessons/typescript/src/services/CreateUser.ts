export function createUser({ name, email, password, techs }: CreateUserData) {
  const user = {
    name,
    email,
    password,
    techs,
  };

  return user;
}

interface CreateUserData {
  name?: string;
  email: string;
  password: string;
  techs: Array<string | TechData>;
}

interface TechData {
  title: string;
  experience: number;
}
