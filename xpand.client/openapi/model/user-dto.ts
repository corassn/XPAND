/**
 * EXPAND.Server
 * No description provided (generated by Openapi Generator https://github.com/openapitools/openapi-generator)
 *
 * The version of the OpenAPI document: v1
 * 
 *
 * NOTE: This class is auto generated by OpenAPI Generator (https://openapi-generator.tech).
 * https://openapi-generator.tech
 * Do not edit the class manually.
 */
import { ObjectId } from './object-id';


export interface UserDto { 
    id: ObjectId;
    name: string;
    userName: string;
    email: string;
    teamId?: string | null;
    token?: string | null;
}

