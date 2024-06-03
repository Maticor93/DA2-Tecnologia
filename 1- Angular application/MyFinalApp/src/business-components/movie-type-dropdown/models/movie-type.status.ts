import DropdownOption from "../../../components/dropdown/models/DropdownOption";

export default interface MovieTypesStatus {
  loading?: true;
  movieTypes: Array<DropdownOption>;
  error?: string;
}

