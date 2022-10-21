#ifndef _SDK_WRAPPER_TOOL_IMPL_
#define _SDK_WRAPPER_TOOL_IMPL_

#include <map>
#include <sstream>
#include <vector>

#include "sdk_wrapper_internal.h"

#define GetJsonValue_String(jnode, name, default_value) (!jnode.HasParseError()  && !jnode.IsNull() \
                                                        && !jnode[name].IsNull() && jnode[name].IsString()) \
                                                        ? jnode[name].GetString() : default_value; 

#define GetJsonValue_Bool(jnode, name, default_value)   (!jnode.HasParseError() && !jnode.IsNull() \
                                                        && !jnode[name].IsNull() && jnode[name].IsBool()) \
                                                        ? jnode[name].GetBool() : default_value; 

template<typename T>
static std::string convert2String(const T& from)
{
    stringstream stream;
    stream << from;
    return stream.str();
}

template<typename T>
static T convertFromString(const std::string& from)
{
    stringstream stream;
    stream << from;
    T to;
    stream >> to;
    return to;
}

void CallBack(const char* method, const char* jstr);
void CallBackProgress(const char* method, const char* jstr);

bool CheckClientInitOrNot(const char* cbid);

string JsonStringFromObject(const Value& obj);

string JsonStringFromResult(const char* cbid, int process, int code, const char* desc, const char* jstr);
string JsonStringFromError(const char* cbid, int code, const char* desc);
string JsonStringFromSuccess(const char* cbid);
string JsonStringFromErrorResult(const char* cbid, int code, const char* desc, const char* jstr);
string JsonStringFromSuccessResult(const char* cbid, const char* jstr);
string JsonStringFromProcess(const char* cbid, int process);

string JsonStringFromVector(vector<string>& vec);
vector<string> JsonStringToVector(string& jstr);

string JsonStringFromMap(map<string, string>& map);
map<string, string> JsonStringToMap(string& jstr);


#endif