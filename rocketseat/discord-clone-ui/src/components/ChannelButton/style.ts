import styled from "styled-components";
import { Hashtag } from "@styled-icons/heroicons-outline";
import { PersonAdd, Settings } from "@styled-icons/material";

export const Container = styled.div`
  align-items: center;
  background-color: transparent;
  border-radius: 3px;
  cursor: pointer;
  display: flex;
  justify-content: space-between;
  padding: 5px 3px;
  transition: background-color 0.2s;

  > div {
    align-items: center;
    display: flex;
  }

  > div span {
    color: var(--senary);
    margin-left: 5px;
  }

  &.active,
  &:hover {
    background-color: var(--quinary);

    > div span {
      color: var(--white);
    }
  }
`;

export const HashtagIcon = styled(Hashtag)`
  color: var(--symbol);
  height: 20px;
  width: 20px;
`;

export const InviteIcon = styled(PersonAdd)`
  color: var(--symbol);
  cursor: pointer;
  height: 16px;
  transition: color 0.2s;
  width: 16px;

  &:hover {
    color: var(--white);
  }
`;

export const SettingsIcon = styled(Settings)`
  color: var(--symbol);
  cursor: pointer;
  height: 16px;
  margin-left: 4px;
  transition: color 0.2s;
  width: 16px;

  &:hover {
    color: var(--white);
  }
`;
