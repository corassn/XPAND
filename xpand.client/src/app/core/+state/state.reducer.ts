import { Action, createReducer } from "@ngrx/store";
import { CoreState } from "./state.models";

export const initialCoreState: CoreState = {
    user: undefined,
}

export const stateReducer = createReducer(initialCoreState);

export function coreReducer(state: CoreState | undefined, action: Action) {
    return stateReducer(state, action);
}