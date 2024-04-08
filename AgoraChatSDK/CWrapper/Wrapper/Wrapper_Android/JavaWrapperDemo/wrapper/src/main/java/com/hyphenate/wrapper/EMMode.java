package com.hyphenate.wrapper;

import com.hyphenate.chat.EMConversation;

public class EMMode {
    public static EMConversation.EMMessageSearchScope searchScopeFromInt(int intType) {
        if (intType == 0){
            return EMConversation.EMMessageSearchScope.CONTENT;
        }else if(intType == 1){
            return EMConversation.EMMessageSearchScope.EXT;
        }else if(intType == 2){
            return EMConversation.EMMessageSearchScope.ALL;
        }else {
            return EMConversation.EMMessageSearchScope.CONTENT;
        }
    }

    public static EMConversation.EMMarkType markTypeFromInt(int intType) {
        switch(intType) {
            case 0:
                return EMConversation.EMMarkType.MARK_0;
            case 1:
                return EMConversation.EMMarkType.MARK_1;
            case 2:
                return EMConversation.EMMarkType.MARK_2;
            case 3:
                return EMConversation.EMMarkType.MARK_3;
            case 4:
                return EMConversation.EMMarkType.MARK_4;
            case 5:
                return EMConversation.EMMarkType.MARK_5;
            case 6:
                return EMConversation.EMMarkType.MARK_6;
            case 7:
                return EMConversation.EMMarkType.MARK_7;
            case 8:
                return EMConversation.EMMarkType.MARK_8;
            case 9:
                return EMConversation.EMMarkType.MARK_9;
            case 10:
                return EMConversation.EMMarkType.MARK_10;
            case 11:
                return EMConversation.EMMarkType.MARK_11;
            case 12:
                return EMConversation.EMMarkType.MARK_12;
            case 13:
                return EMConversation.EMMarkType.MARK_13;
            case 14:
                return EMConversation.EMMarkType.MARK_14;
            case 15:
                return EMConversation.EMMarkType.MARK_15;
            case 16:
                return EMConversation.EMMarkType.MARK_16;
            case 17:
                return EMConversation.EMMarkType.MARK_17;
            case 18:
                return EMConversation.EMMarkType.MARK_18;
            case 19:
                return EMConversation.EMMarkType.MARK_19;
            default:
                return EMConversation.EMMarkType.MARK_0;
        }
    }
}
